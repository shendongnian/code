    void page1(){
        txtStory.Text = "Can you sneak past the enemy?";
    
        void Btn1Click(object s, EventArgs ev)
        {
            luckCheck();
            if (lucky) {page2(); clearButtons(); btn1.Click -= Btn1Click; }
            else {page3(); clearButtons();}
        };
    
        btn1.Click += Btn1Click;
    
        void luckCheck(){
        int luckTest = gen.Next(1,12);
        if (luckTest <= playerLuck) {lucky = true;}
        else {lucky = false;}
        }
    
        void clearButtons(){
        btnN.Text = "";
        btnS.Text = "";
        btnE.Text = "";
        btnW.Text = "";
        btn1.Text = "";
        btn2.Text = "";
        btn3.Text = "";
        btn4.Text = "";
        btn5.Text = "";
        btn6.Text = "";
        }
    
        void page2(){
        txtStory.Text = "Lucky!";
        }
    
        void page3(){
        txtStory.Text = "Not Lucky!";
        }
    
    
