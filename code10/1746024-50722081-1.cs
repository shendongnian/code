    public class AudioControl: MonoBehaviour {
    void SetVolume(Slider slider) {
        AudioListener.volume = slider.Value;
        // probably save this value to a playerpref so it is remembered. 
        }
    }
