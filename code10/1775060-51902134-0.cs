    using System;
    using System.IO;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    
    public class DocEnabler : MonoBehaviour
    {
        //Replace both with the proper paths on your system
        static string unityFrameworkPath = @"G:\Applications\Unity\Editor\Data\MonoBleedingEdge\lib\mono\unity";
        static string stdCoreFrameworkPath = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v3.5\Profile\Client";
    
        [MenuItem("Programmer/Enable Core Documentation")]
        static void EnableCoreDoc()
        {
            CopyFilesByExt(stdCoreFrameworkPath, unityFrameworkPath, "xml");
        }
    
        [MenuItem("Programmer/Disable Core Documentation")]
        static void DisableCoreDoc()
        {
            DeleteFilesByExt(unityFrameworkPath, "xml");
        }
    
        static void DeleteFilesByExt(string path, string ext)
        {
            DirectoryInfo drctyInfo = new DirectoryInfo(path);
            FileInfo[] files = drctyInfo.GetFiles("*." + ext)
                                 .Where(p => p.Extension == "." + ext).ToArray();
    
            foreach (FileInfo file in files)
            {
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    file.Delete();
                    //File.Delete(file.FullName);
                }
                catch (Exception e)
                {
                    Debug.Log("Error while deleting file: " + file.Name + "\r\n" + e.Message);
                }
            }
            DoneMessage();
        }
    
        static void CopyFilesByExt(string source, string destPath, string ext)
        {
            DirectoryInfo drctyInfo = new DirectoryInfo(source);
            FileInfo[] files = drctyInfo.GetFiles("*." + ext)
                                 .Where(p => p.Extension == "." + ext).ToArray();
    
            foreach (FileInfo file in files)
            {
                try
                {
                    string fromPath = file.FullName;
                    string toPath = Path.Combine(destPath, file.Name);
    
                    file.CopyTo(toPath, true);
                    //File.Copy(fromPath, toPath, true);
                }
                catch (Exception e)
                {
                    Debug.Log("Error while Copying file: " + file.Name + "\r\n" + e.Message);
                }
            }
            DoneMessage();
        }
    
        static void DoneMessage()
        {
            Debug.Log("Action complete. Restart Visual Studio for the changes to take effect");
        }
    }
