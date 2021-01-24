            if (Control != null)
            {
                Control.SetAllCaps(false);
                GradientDrawable gradientDrawable = new GradientDrawable();                
                float[] radius= new float[8];
                radius[0] = 46f;   //Top Left corner
                radius[1] = 46f;   //Top Left corner
                radius[2] = 0;     //Top Right corner
                radius[3] = 0;     //Top Right corner
                radius[4] = 0;     //Bottom Right corner
                radius[5] = 0;     //Bottom Right corner
                radius[6] = 46f;   //Bottom Left corner
                radius[7] = 46f;   //Bottom Left corner
                gradientDrawable.SetCornerRadii(radius);
                Control.SetBackground(gradientDrawable);
            }
        }
