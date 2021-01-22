    bool _closingFromMenu;
    void NOTIFYICON_EXIT_MENU_HANDLER(object sender, EventArgs e)
    {
        _closingFromMenu = true;
        Close();
    }
    //form closing handler
    FormClosing +=(a,b) =>{
        if(_closingFromMenu){
            Close();
        }
        else{
            e.Cancel = true;
            //do minimize stuff;
        }
    }
