    using UnityEngine;
    using Vuforia;
    
    public class Cameraa : MonoBehaviour
    {
        private bool on = true;
    
        public void Switch()
        {
            on = !on;
            if (on)
            {
                CameraDevice.Instance.Stop();
                CameraDevice.Instance.Deinit();
                TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
    
                CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_BACK);
                CameraDevice.Instance.Start();
                TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
    
            }
            else if (!on)
            {
                CameraDevice.Instance.Stop();
                CameraDevice.Instance.Deinit();
    
                TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
                CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_FRONT);
    
                CameraDevice.Instance.Start();
                TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
            }
        }
    }
