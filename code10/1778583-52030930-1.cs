    public class EasyRawImage : EasyUIELementFoundation
    {
        private RawImage UIImageComponent = UIElement.AddComponent(typeof(RawImage));
        private Texture2D _image;
    
        public Texture2D Image
        {
            get
            {
                return _image;
            }
            set
            {
                UIImageComponent.texture = value;
                _image = value;
            }
        }
    
        public EasyRawImage() : base()
        {
        }
    
        public EasyRawImage(UnityEngine.Object image, Vector2 position) : base(position)  
        {
             //some code...
        }
    
    }
