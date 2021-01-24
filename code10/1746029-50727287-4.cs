    using System.Runtime.InteropServices;
    using UnityEngine;
    
    public class VolumeManager : MonoBehaviour
    {
        //The Unit to use when getting and setting the volume
        public enum VolumeUnit
        {
            //Perform volume action in decibels</param>
            Decibel,
            //Perform volume action in scalar
            Scalar
        }
    
        /// <summary>
        /// Gets the current volume
        /// </summary>
        /// <param name="vUnit">The unit to report the current volume in</param>
        [DllImport("ChangeVolumeWindows")]
        public static extern float GetSystemVolume(VolumeUnit vUnit);
        /// <summary>
        /// sets the current volume
        /// </summary>
        /// <param name="newVolume">The new volume to set</param>
        /// <param name="vUnit">The unit to set the current volume in</param>
        [DllImport("ChangeVolumeWindows")]
        public static extern void SetSystemVolume(double newVolume, VolumeUnit vUnit);
    
        // Use this for initialization
        void Start()
        {
            //Get volume in Decibel 
            float volumeDecibel = GetSystemVolume(VolumeUnit.Decibel);
            Debug.Log("Volume in Decibel: " + volumeDecibel);
    
            //Get volume in Scalar 
            float volumeScalar = GetSystemVolume(VolumeUnit.Scalar);
            Debug.Log("Volume in Scalar: " + volumeScalar);
    
            //Set volume in Decibel 
            SetSystemVolume(-16f, VolumeUnit.Decibel);
    
            //Set volume in Scalar 
            SetSystemVolume(0.70f, VolumeUnit.Scalar);
        }
    }
