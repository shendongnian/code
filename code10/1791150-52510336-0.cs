    using System.Threading;		
    public ManualResetEvent mre = new ManualResetEvent(false); // created in the unsignaled state.
		public Task<CameraImage> GetImageFromCameraAsync(string cameraId)
		{
			mre.Reset(); // Set the state of the event to be nonsignaled 
			APIHandler = new CanonAPI();
			Camera MainCamera = APIHandler.GetCameraList()[0];
			MainCamera.DownloadReady += Cam_DownloadReady;
			MainCamera.OpenSession();
			MainCamera.TakePhotoAsync();
			// wait here until event occurs and is processed
			mre.WaitOne(); // Block the current thread until the current wait handle receives a signal
			// Cam_DownloadReady(...) is called and finished
			// continue ...
		}
		private void Cam_DownloadReady(Camera sender, DownloadInfo Info)
		{
			sender.DownloadFile(Info, saveImageDir); //save picture on PC
			mre.Set(); // Set the state of the event to signaled, allowing mre.WaitOne() above to proceed.
		}
