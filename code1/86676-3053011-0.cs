    public class ImagePropertyAccessor : IPropertyAccessor
    {
        #region Setter
        private class ImageGetterSetter : IGetter, ISetter {
            PropertyInfo _property;
            ImageFormat _imageFormat;
            public ImageGetterSetter(PropertyInfo property, ImageFormat imageFormat)
            {
                if (property == null) throw new ArgumentNullException("property");
                if (property.PropertyType != typeof(Image)) throw new ArgumentException("property");
                _property = property;
                _imageFormat = imageFormat;
            }
            public void Set(object target, object value) {
                var image = Deserialise((byte[]) value);
                _property.SetValue(target, image, null);
            }
            public object Get(object target)
            {
                var image = (Image)_property.GetValue(target, null);
                var data = Serialise(image);
                return data;
            }
            private byte[] Serialise(Image image)
            {
                if (image == null)
                    return null;
                var ms = new MemoryStream();
                image.Save(ms, _imageFormat);
                return ms.ToArray();
            }
            private Image Deserialise(byte[] data)
            {
                if (data == null || data.Length == 0)
                    return null;
                var ms = new MemoryStream(data);
                return Image.FromStream(ms);
            }
            public object GetForInsert(object owner, IDictionary mergeMap, ISessionImplementor session)
            {
                return Get(owner);
            }
            public Type ReturnType
            {
                get { return typeof (byte[]); }
            }
            public string PropertyName {
                get { return _property.Name; }
            }
            public MethodInfo Method {
                get { return null; }
            }
        }
        #endregion
        public IGetter GetGetter(Type theClass, string propertyName) {
            return new ImageGetterSetter(theClass.GetProperty(propertyName), ImageFormat.Bmp);
        }
        public ISetter GetSetter(Type theClass, string propertyName) {
            return new ImageGetterSetter(theClass.GetProperty(propertyName), ImageFormat.Bmp);
        }
        public bool CanAccessThroughReflectionOptimizer {
            get { return false; }
        }
    }
