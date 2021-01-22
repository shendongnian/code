    int moveCommandToggle = 0;
    protected override void WndProc(ref Message m)
    {
       if (m.Msg == 0x0312)
       {
         int keyID = m.WParam.ToInt32();
         if(keyID == some_key_combo_you_registered_for_the_moving)
         {
             if (moveCommandToggle++ % 2 == 0)
             {
                mover = new Thread(() => MoveWindow_AfterMouse());
                mover.Start();
             }
             else mover.Abort();
          }
        }
     }
