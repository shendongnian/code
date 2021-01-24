    using UnityEngine;
    using System.Collections.Generic;
    
    [RequireComponent(typeof(AudioSource))]
    public class Data : MonoBehaviour
    {
        AudioSource _audio;
        public float[] _samples1 = new float[512];
        public List<float> arreglo = new List<float>();
    
        void Start()
        {
            _audio = GetComponent<AudioSource>();
            _audio.clip = Microphone.Start("Built-in Microphone", true, 15, 44100);
        }
    
        void Update()
        {
            GetSpectrum();
            
            // optional if you want to clear old data
            arreglo.Clear();
            
            // replace 15 with '_samples1.Length' for adding all values
            for (int i = 0; i < 15; i++)
            {
                arreglo.Add(_samples1[i]);
            }
        }
    
        void GetSpectrum()
        {
            _audio.GetSpectrumData(_samples1, 0, FFTWindow.Blackman);
        }
    }
