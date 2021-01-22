    private void button1_Click(object sender, System.EventArgs e)
    {
        m_sysTray.StopAnimation();
        Bitmap bmp = new Bitmap("tick.bmp");
        // the color from the left bottom pixel will be made transparent
        bmp.MakeTransparent();
        m_sysTray.SetAnimationClip(bmp);
        m_sysTray.StartAnimation(150, 5);
    }
 
