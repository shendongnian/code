    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Devices.Enumeration;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.Media.Capture;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Windows.Media.MediaProperties;
    using Windows.Media.Playback;
    using Windows.Storage;
    using Windows.Storage.Streams;
    using Windows.ApplicationModel.Core;
    using Windows.UI.Core;
    
    namespace Recording_PI
    {
        /// <summary>
        /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            bool isRecording;
            LowLagMediaRecording audioRecording;
            MediaCapture audioCapture = new MediaCapture();
    
            public MainPage()
            {
                this.InitializeComponent();
    
                Checked();
    
    
            }
    
            private async void Checked()
            {
                try
                {
                    var settings = new Windows.Media.Capture.MediaCaptureInitializationSettings();
                    settings.StreamingCaptureMode = Windows.Media.Capture.StreamingCaptureMode.Audio;
                    settings.MediaCategory = Windows.Media.Capture.MediaCategory.Other;
                    settings.AudioProcessing = Windows.Media.AudioProcessing.Default;
                    await audioCapture.InitializeAsync(settings);
    
                    StorageFolder externalDevices = KnownFolders.RemovableDevices;
                    IReadOnlyList<StorageFolder> externalDrives = await externalDevices.GetFoldersAsync();
                    StorageFolder usbStorage = externalDrives[0];
    
                    //ENSURE FOLDER EXISTS
                    if (await usbStorage.TryGetItemAsync("Recording") == null)
                        await usbStorage.CreateFolderAsync("Recording");
    
                    string Folder_Pfad = "Recording\\" + DateTime.Now.Year.ToString();
                    if (await usbStorage.TryGetItemAsync(Folder_Pfad) == null)
                        await usbStorage.CreateFolderAsync(Folder_Pfad);
    
                    Folder_Pfad = Folder_Pfad + "\\" + DateTime.Now.Month.ToString();
                    if (await usbStorage.TryGetItemAsync(Folder_Pfad) == null)
                        await usbStorage.CreateFolderAsync(Folder_Pfad);
    
                    Folder_Pfad = Folder_Pfad + "\\" + DateTime.Now.Day.ToString();
                    if (await usbStorage.TryGetItemAsync(Folder_Pfad) == null)
                        await usbStorage.CreateFolderAsync(Folder_Pfad);
    
                    string Dateiname = "\\" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " "
                         + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + ".mp3";
    
                    string Dateispeicher_Ort = Folder_Pfad + Dateiname;
    
                    StorageFile recordFile = await usbStorage.CreateFileAsync(Dateispeicher_Ort, Windows.Storage.CreationCollisionOption.GenerateUniqueName);
    
                    isRecording = true;
                    //await audioCapture.StartRecordToStorageFileAsync(MediaEncodingProfile.CreateMp3(AudioEncodingQuality.Auto), recordFile);
    
                    var audioRecording = await audioCapture.PrepareLowLagRecordToStorageFileAsync(MediaEncodingProfile.CreateM4a(AudioEncodingQuality.Medium), recordFile);
                    await audioRecording.StartAsync();
    
                    Task.Delay(10000).Wait();
                    Unchecked();
                }
                catch (Exception ex)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, ()=> {
                        Result.Text += ex.Message;
                    });
    
                }
    
            }
    
    
            private async void Unchecked()
            {
                if (isRecording)
                {
                    await audioCapture.StopRecordAsync();
                }
    
            }
    
        }
    }
