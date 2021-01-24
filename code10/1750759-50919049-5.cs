    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.ApplicationModel.Core;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Core;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    namespace VideoSamplePlayer
    {
        public sealed partial class MainPage : Page
        {
            int newViewID = 0;
            Window VideoPlayerWindow;
            // To store the reference to the view control, so that it's dispatcher
            //    can be used to schedule more work on its thread.
            CoreApplicationView VideoPlayerView { get; set; }
            // The custom event declaration, to be raised when a media source for the video
            //      is selected.
            public delegate void VideoSelectedHandler(object sender, VideoSelectionArgs e);
            public event VideoSelectedHandler VideoSelected;
            private void RaiseVideoSelectedEvent(MediaSource source)
            {
                // Ensure that something is listening to the event.
                if (this.VideoSelected != null)
                {
                    // Create the args, and call the listening event handlers.
                    VideoSelectionArgs args = new VideoSelectionArgs(source);
                    this.VideoSelected(this, args);
                }
            }
            public MainPage()
            {
                this.InitializeComponent();
            }
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                if (newViewID == 0)
                {
                    // Store the newly created view control.
                    this.VideoPlayerView = CoreApplication.CreateNewView();
                    await this.VideoPlayerView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        Frame newFrame = new Frame();
                        newFrame.Navigate(typeof(VideoPlayer), null);
                        // Have the new VideoPlayer page subscribe to the media source selection event on this page.
                        VideoPlayer videoPlayerPage = newFrame.Content as VideoPlayer;
                        this.VideoSelected += videoPlayerPage.VideoSelected;
                        Window.Current.Content = newFrame;
                        Window.Current.Activate();
                        VideoPlayerWindow = Window.Current;
                        newViewID = ApplicationView.GetForCurrentView().Id;
                    });
                    await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewID, ViewSizePreference.UseMinimum);
                }
            }
            private async void pickFileButton_Click(object sender, RoutedEventArgs e)
            {
                // Schedule the work here on the same thread as the VideoPlayer window,
                //    so that it has access to the file and MediaSource to play.
                await this.VideoPlayerView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    // Create and open the file picker
                    FileOpenPicker openPicker = new FileOpenPicker();
                    openPicker.ViewMode = PickerViewMode.Thumbnail;
                    openPicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
                    openPicker.FileTypeFilter.Add(".mp4");
                    openPicker.FileTypeFilter.Add(".mkv");
                    openPicker.FileTypeFilter.Add(".avi");
                    StorageFile file = await openPicker.PickSingleFileAsync();
                    if (file != null)
                    {
                        MediaSource sourceFromFile = MediaSource.CreateFromStorageFile(file);
                        // Raise the event declaring that a video was selected.
                        this.RaiseVideoSelectedEvent(sourceFromFile);
                    }
                });
            }
        }
        // Class definition for the custom event args, which allows a 
        //     media source to be passed to any event handlers that are listening.
        public class VideoSelectionArgs : EventArgs
        {
            public MediaSource Source { get; private set; }
            public VideoSelectionArgs(MediaSource source)
            {
                this.Source = source;
            }
        }
    }
