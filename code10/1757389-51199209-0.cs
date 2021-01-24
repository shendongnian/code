    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Rendering.PostProcessing; //How you'll access PPV (Post Processing Volume) models and settings
    public class BrightnessSlider : MonoBehaviour {
        PostProcessingVolume ppv; //You can make this public to set in inspector
        ColorGradingModel cgm; //can use ppv.profile.TryGetSettings(out cgm) in Start()
        public void SetBrightness (float brightness)
        {
            cg.[setting you want to change].value = brightness;
        }
    }
   
