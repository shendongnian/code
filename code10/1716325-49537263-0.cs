    using UnityEngine;
    using System.Collections;
    using UnityEngine.Video;
    
    public class Movie : MonoBehaviour
    {
        public Video3DLayout myLayout;
    
        void Start()
        {
            // Will attach a VideoPlayer to the main camera.
            GameObject camera = GameObject.Find("Main Camera");
    
            // VideoPlayer automatically targets the camera backplane when it is added
            // to a camera object, no need to change videoPlayer.targetCamera.
            var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
            videoPlayer.targetCamera3DLayout = myLayout;
    
            // Play on awake defaults to true. Set it to false to avoid the url set
            // below to auto-start playback since we're in Start().
            videoPlayer.playOnAwake = false;
    
            // By default, VideoPlayers added to a camera will use the far plane.
            // Let's target the near plane instead.
            videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
    
            // Set the video to play.
            videoPlayer.url = "movie.mp4";
    
            // Start playback. This means the VideoPlayer may have to prepare (reserve
            // resources, pre-load a few frames, etc.). To better control the delays
            // associated with this preparation one can use videoPlayer.Prepare() along with
            // its prepareCompleted event.
            videoPlayer.Play();
        }
    }
