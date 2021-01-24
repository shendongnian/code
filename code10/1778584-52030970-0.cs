    public class EasyRawImage : EasyUIELementFoundation
    {
        private RawImage UIImageComponent;
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
    
        public EasyRawImage() : this(default(UnityEngine.Object), default(Vector2))
        {
        }
    
        public EasyRawImage(UnityEngine.Object image, Vector2 position) : base(position)
        {
             UIImageComponent = UIElement.AddComponent(typeof(RawImage)) as RawImage;
             //some code...
        }
    }
