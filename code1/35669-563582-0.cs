    internal class ReflectionCopy
    {
        public static ToType Copy<ToType>(object from) where ToType : new()
        {
            return (ToType)Copy(typeof(ToType), from);
        }
        public static object Copy(Type totype, object from)
        {
            object to = Activator.CreateInstance(totype);
            PropertyInfo[] tpis = totype.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] fpis = from.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Array.ForEach(tpis, tpi =>
            {
                PropertyInfo fpi = Array.Find(fpis, pi => pi.Name == tpi.Name);
                if (fpi != null)
                {
                    if (fpi.PropertyType != tpi.PropertyType)
                    {
                        PropertyDescriptorCollection desc = TypeDescriptor.GetProperties(totype);
                        ReflectionTypeDescriptorContext context = new ReflectionTypeDescriptorContext()
                        {
                            PropertyDescriptor = desc[tpi.Name],
                        };
                        TypeConverter conv = TypeDescriptor.GetConverter(tpi.PropertyType);
                        if (conv.CanConvertFrom(context, fpi.PropertyType))
                        {
                            tpi.SetValue(to, conv.ConvertFrom(context, System.Globalization.CultureInfo.CurrentCulture, fpi.GetValue(from, null)), null);
                        }
                    }
                    else
                    {
                        tpi.SetValue(to, fpi.GetValue(from, null), null);
                    }
                }
            });
            return to;
        }
    }
    internal class ReflectionConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            System.ComponentModel.Design.Serialization.InstanceDescriptor desc;
            return context.PropertyDescriptor.PropertyType.Name == destinationType.Name;
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return context.PropertyDescriptor.PropertyType.Name == sourceType.Name;
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            return ReflectionCopy.Copy(context.PropertyDescriptor.PropertyType, value);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return ReflectionCopy.Copy(context.PropertyDescriptor.PropertyType, value);
        }
    }
    
    namespace Rate
    {
        [TypeConverter(typeof(ReflectionConverter))]
        partial class WebAuthenticationDetail
        {
            public static implicit operator Ship.WebAuthenticationDetail(WebAuthenticationDetail from)
            {
                return ReflectionCopy.Copy<Ship.WebAuthenticationDetail>(from);
            }
        }
        [TypeConverter(typeof(ReflectionConverter))]
        partial class WebAuthenticationCredential
        {
            public static implicit operator Ship.WebAuthenticationCredential(WebAuthenticationCredential from)
            {
                return ReflectionCopy.Copy<Ship.WebAuthenticationCredential>(from);
            }
        }
    }
    namespace Ship
    {
        [TypeConverter(typeof(ReflectionConverter))]
        partial class WebAuthenticationDetail
        {
            public static implicit operator Rate.WebAuthenticationDetail(WebAuthenticationDetail from)
            {
                return ReflectionCopy.Copy<Rate.WebAuthenticationDetail>(from);
            }
        }
        [TypeConverter(typeof(ReflectionConverter))]
        partial class WebAuthenticationCredential
        {
            public static implicit operator Rate.WebAuthenticationCredential(WebAuthenticationCredential from)
            {
                return ReflectionCopy.Copy<Rate.WebAuthenticationCredential>(from);
            }
        }
    }
    internal class ReflectionTypeDescriptorContext : ITypeDescriptorContext
    {
        #region ITypeDescriptorContext Members
        public IContainer Container
        {
            get { throw new NotImplementedException(); }
        }
        public object Instance
        {
            get { throw new NotImplementedException(); }
        }
        public void OnComponentChanged()
        {
            throw new NotImplementedException();
        }
        public bool OnComponentChanging()
        {
            throw new NotImplementedException();
        }
        public PropertyDescriptor PropertyDescriptor
        {
            get;
            set;
        }
        #endregion
        #region IServiceProvider Members
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
