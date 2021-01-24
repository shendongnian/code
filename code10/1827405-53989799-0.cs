    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    
    using UnityEngine;
    
    using HedgehogTeam.EasyTouch;
    
    namespace TouchControls
    {
        /// <summary>Helper to control touch-based input.</summary>
        public static class Utility
        {
            const string imageNamespace = "TouchControls.";
            const string imageResourceFolder = "TouchControls/Images/";
            /// <summary>Static helper to contain texture resources.</summary>
            public static class Texture
            {
                /// <summary>The texture used to represent a second finger when simulating touches.</summary>
                public static Texture2D SecondFinger
                {
                    get
                    {
                        if (null == secondFinger)
                            secondFinger = LoadImage(secondFingerFilename);
    
                        return secondFinger;
                    }
                }
                static Texture2D secondFinger = null;
                const string secondFingerFilename = "secondFinger.png";
            }
    
            static Assembly ExecutingAssembly
            {
                get
                {
                    if (null == executingAssembly)
                    {
                        executingAssembly = Assembly.GetExecutingAssembly();
                    }
                    return executingAssembly;
                }
            }
            static Assembly executingAssembly = null;
            static Stream GetImageStream(string imageName) { return ExecutingAssembly.GetManifestResourceStream(imageName); }
    
            static Texture2D LoadImage(string filename, TextureWrapMode wrapMode = TextureWrapMode.Clamp, FilterMode filterMode = FilterMode.Bilinear, bool useMipMaps = true, TextureFormat format = TextureFormat.ARGB32)
            {
                Texture2D texture = Resources.Load<Texture2D>(imageResourceFolder + Path.GetFileNameWithoutExtension(!string.IsNullOrEmpty(filename) ? filename : string.Empty));
                try
                {
                    // Didn't find it in resources in the project so try to find it in the library manifest....
                    if (null == texture)
                    {
                        using (Stream stream = GetImageStream(imageNamespace + filename))
                        {
                            texture = new Texture2D(0, 0, format, useMipMaps);
                            if (!texture.LoadImage(GetImageBuffer(stream)))
                                throw new NotSupportedException(filename);
    
                            texture.wrapMode = wrapMode;
                            texture.filterMode = filterMode;
                        }
                    }
                    else // ensure it is read/write enabled...
                    {
                        Texture2D invertedTexture = new Texture2D(texture.width, texture.height, texture.format, 1 < texture.mipmapCount);
                        invertedTexture.SetPixels32(texture.GetPixels32());
                        invertedTexture.Apply(true);
                        texture = invertedTexture;
                    }
                }
                catch
                {
                    // Something went wrong so make a magenta 4 pixel texture.
                    texture = new Texture2D(2, 2, TextureFormat.ARGB32, false);
                    texture.SetPixels(0, 0, 2, 2, Enumerable.Repeat(Color.magenta, 4).ToArray());
                }
                texture.Apply(true);
    
                return texture;
            }
    
            static byte[] GetImageBuffer(Stream stream)
            {
                stream.Seek(0, SeekOrigin.Begin);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
    
                return buffer;
            }
        }
    }
