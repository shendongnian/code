    // Passing null for either maxWidth or maxHeight maintains aspect ratio while
    //        the other non-null parameter is guaranteed to be constrained to
    //        its maximum value.
    //
    //  Example: maxHeight = 50, maxWidth = null
    //    Constrain the height to a maximum value of 50, respecting the aspect
    //    ratio, to any width.
    //
    //  Example: maxHeight = 100, maxWidth = 90
    //    Constrain the height to a maximum of 100 and width to a maximum of 90
    //    whichever comes first.
    //
    private static Size ScaleSize( Size from, int? maxWidth, int? maxHeight )
    {
       if ( !maxWidth.HasValue && !maxHeight.HasValue ) throw new ArgumentException( "At least one scale factor (toWidth or toHeight) must not be null." );
       if ( from.Height == 0 || from.Width == 0 ) throw new ArgumentException( "Cannot scale size from zero." );
       double? widthScale = null;
       double? heightScale = null;
       if ( maxWidth.HasValue )
       {
           widthScale = maxWidth.Value / (double)from.Width;
       }
       if ( maxHeight.HasValue )
       {
           heightScale = maxHeight.Value / (double)from.Height;
       }
       double scale = Math.Min( (double)(widthScale ?? heightScale),
                                (double)(heightScale ?? widthScale) );
       return new Size( (int)Math.Floor( from.Width * scale ), (int)Math.Ceiling( from.Height * scale ) );
    }
