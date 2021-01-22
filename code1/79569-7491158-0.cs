    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    
    namespace UI.Extensions.Wpf.Controls
    {
        public class ChildPopup : Popup
        {
            static ChildPopup()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(ChildPopup), new FrameworkPropertyMetadata(typeof(ChildPopup)));
            }
    
            public ChildPopup()
            {
                Type baseType = this.GetType().BaseType;
                dynamic popupSecHelper = GetHiddenField(this, baseType, "_secHelper");
                SetHiddenField(popupSecHelper, "_isChildPopupInitialized", true);
                SetHiddenField(popupSecHelper, "_isChildPopup", true);
            }
    
            protected dynamic GetHiddenField(object container, string fieldName)
            {
                return GetHiddenField(container, container.GetType(), fieldName);
            }
    
            protected dynamic GetHiddenField(object container, Type containerType, string fieldName)
            {
                dynamic retVal = null;
                FieldInfo fieldInfo = containerType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                {
                    retVal = fieldInfo.GetValue(container);
                }
                return retVal;
            }
    
            protected void SetHiddenField(object container, string fieldName, object value)
            {
                SetHiddenField(container, container.GetType(), fieldName, value);
            }
    
            protected void SetHiddenField(object container, Type containerType, string fieldName, object value)
            {
                FieldInfo fieldInfo = containerType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo != null)
                {
                    fieldInfo.SetValue(container, value);
                }
            }
        }
    }
