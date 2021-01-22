    class MyForm : Form
    {
        // From the designer code:
        Button btnX;
        Button btnY;
    
        void InitializeComponent()
        {
            ...
            btnX.Clicked += btnX_Clicked;
            btnY.Clicked += btnY_Clicked;
            ...
        }
    
        Button btnLastPressed = null;
        int counter = 0;
    
        void btnX_Clicked(object source, EventArgs e)
        {
            if (btnLastPressed == btnY)
            {
                // button Y was pressed first, so decrement the counter
                --counter;
                // reset the state for the next button press
                btnLastPressed = null;
            }
            else
            {
                btnLastPressed = btnX;
            }
        }
    
        void btnY_Clicked(object source, EventArgs e)
        {
            if (btnLastPressed == btnX)
            {
                // button X was pressed first, so increment the counter
                ++counter;
                // reset the state for the next button press
                btnLastPressed = null;
            }
            else
            {
                btnLastPressed = btnY;
            }
        }
    }
