    //using System.Drawing;
    #region MakeTransparentIcon
        ///<summary>
        /// Manipulates the background of an Icon
        ///</summary>
        ///<param name="icon">Icon source</param>
        ///<param name="disposeIcon">Icon dispose</param>
        ///<returns><see cref="Icon"/> or <see cref="T:null"/></returns>
        public static Icon MakeTransparentIcon(Icon icon, bool disposeIcon = true)
        {
            if (icon != null)
            {
                using (Bitmap bm = icon.ToBitmap())
                {
                    bm.MakeTransparent(Color.Transparent); // define the background as transparent
                                                           // you need to align the color to your needs
                    if (disposeIcon)
                    {
                        icon.Dispose();
                    }
                    return Icon.FromHandle(bm.GetHicon());
                }
            }
            return null;
        }
        #endregion
