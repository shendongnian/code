    bool mMakeTone = false;
    private void ProduceTone(){
        while(this.Visibility == Visibility.Visible){
            if(mMakeTone ){
                Console.Beep(800, 500); // 500Hz tone for half a second
            }
            else{
                Thread.Sleep(10);
            }
        }
    }
