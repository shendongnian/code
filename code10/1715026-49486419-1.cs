    using System;
    using System.Runtime.InteropServices;
    using UnityEngine;
    
    public class Test : MonoBehaviour
    {
        [DllImport("ImageInputInterface")]
        private static extern void GetRawImageBytes(IntPtr data, int width, int height);
    
        private Texture2D tex;
        private Color32[] pixel32;
    
        private GCHandle pixelHandle;
        private IntPtr pixelPtr;
    
        void Start()
        {
            InitTexture();
            gameObject.GetComponent<Renderer>().material.mainTexture = tex;
        }
    
    
        void Update()
        {
            MatToTexture2D();
        }
    
    
        void InitTexture()
        {
            tex = new Texture2D(512, 512, TextureFormat.ARGB32, false);
            pixel32 = tex.GetPixels32();
            //Pin pixel32 array
            pixelHandle = GCHandle.Alloc(pixel32, GCHandleType.Pinned);
            //Get the pinned address
            pixelPtr = pixelHandle.AddrOfPinnedObject();
        }
    
        void MatToTexture2D()
        {
            //Convert Mat to Texture2D
            GetRawImageBytes(pixelPtr, tex.width, tex.height);
            //Update the Texture2D with array updated in C++
            tex.SetPixels32(pixel32);
            tex.Apply();
        }
    
        void OnApplicationQuit()
        {
            //Free handle
            pixelHandle.Free();
        }
    }
