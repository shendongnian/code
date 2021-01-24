    public class HPsc
    {
        public Image HP_Bar_Green;
        public Image HP_Bar_Red; // Allows me to initialize the images in Unity
    
        void Start()
        {
            HP_Bar_Green = this.GetComponent<Image>();
            HP_Bar_Red = this.GetComponent<Image>();
        }
    }
