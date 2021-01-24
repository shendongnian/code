    `using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System.IO;
    using UnityEngine.UI;
    using System.Runtime;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization;
    using NAudio;
    using NAudio.Wave;
    using UnityEngine.Networking;
    using SimpleFileBrowser;`
   
    public class ReadMp3 : MonoBehaviour{
    private AudioSource audioSource;
    public Text pathText;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ReadMp3Sounds()
    {
        FileBrowser.SetFilters(false, new FileBrowser.Filter("Sounds", ".mp3"));
        FileBrowser.SetDefaultFilter(".mp3");
        StartCoroutine(ShowLoadDialogCoroutine());
    }
    IEnumerator ShowLoadDialogCoroutine()
    {
        
        yield return FileBrowser.WaitForLoadDialog(false, null, "Select Sound", "Select");
    
        pathText.text = FileBrowser.Result;
    
        if (FileBrowser.Success)
        {
            byte[] SoundFile = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result);
            yield return SoundFile;
    
            audioSource.clip = NAudioPlayer.FromMp3Data(SoundFile);
            audioSource.Play();   
        }
    }
      
