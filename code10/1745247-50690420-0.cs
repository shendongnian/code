    using System;
    using System.IO;
    using UnityEngine;
    using UnityEngine.Networking;
    
    public class CustomWebRequest : DownloadHandlerScript
    {
        // Standard scripted download handler - will allocate memory on each ReceiveData callback
        public CustomWebRequest()
            : base()
        {
        }
    
        // Pre-allocated scripted download handler
        // Will reuse the supplied byte array to deliver data.
        // Eliminates memory allocation.
        public CustomWebRequest(byte[] buffer)
            : base(buffer)
        {
    
            Init();
        }
    
        // Required by DownloadHandler base class. Called when you address the 'bytes' property.
        protected override byte[] GetData() { return null; }
    
        // Called once per frame when data has been received from the network.
        protected override bool ReceiveData(byte[] byteFromServer, int dataLength)
        {
            if (byteFromServer == null || byteFromServer.Length < 1)
            {
                Debug.Log("CustomWebRequest :: ReceiveData - received a null/empty buffer");
                return false;
            }
    
            //Write the current data chunk to file
            AppendFile(byteFromServer, dataLength);
    
            return true;
        }
    
        //Where to save the video file
        string vidSavePath;
        //The FileStream to save the file
        FileStream fileStream = null;
        //Used to determine if there was an error while opening or saving the file
        bool success;
    
        void Init()
        {
            vidSavePath = Path.Combine(Application.persistentDataPath, "Videos");
            vidSavePath = Path.Combine(vidSavePath, "MyVideo.webm");
    
    
            //Create Directory if it does not exist
            if (!Directory.Exists(Path.GetDirectoryName(vidSavePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(vidSavePath));
            }
    
    
            try
            {
                //Open the current file to write to
                fileStream = new FileStream(vidSavePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                Debug.Log("File Successfully opened at" + vidSavePath.Replace("/", "\\"));
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                Debug.LogError("Failed to Open File at Dir: " + vidSavePath.Replace("/", "\\") + "\r\n" + e.Message);
            }
        }
    
        void AppendFile(byte[] buffer, int length)
        {
            if (success)
            {
                try
                {
                    //Write the current data to the file
                    fileStream.Write(buffer, 0, length);
                    Debug.Log("Written data chunk to: " + vidSavePath.Replace("/", "\\"));
                }
                catch (Exception e)
                {
                    success = false;
                }
            }
        }
    
        // Called when all data has been received from the server and delivered via ReceiveData
        protected override void CompleteContent()
        {
            if (success)
                Debug.Log("Done! Saved File to: " + vidSavePath.Replace("/", "\\"));
            else
                Debug.LogError("Failed to Save File to: " + vidSavePath.Replace("/", "\\"));
    
            //Close filestream
            fileStream.Close();
        }
    
        // Called when a Content-Length header is received from the server.
        protected override void ReceiveContentLength(int contentLength)
        {
            //Debug.Log(string.Format("CustomWebRequest :: ReceiveContentLength - length {0}", contentLength));
        }
    }
