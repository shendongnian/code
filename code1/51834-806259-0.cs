        try
        {
            _Accpt.Bind(_Point);
            _Accpt.Listen(2); //Second exception is here after the code continues after the catch block
            _Accpt.BeginAccept(null, 0, new AsyncCallback(Accept), _Accpt);
        }
        catch (SocketException exc)
        {
            System.Windows.Forms.MessageBox.Show(exc.Message);
        }
        finally
        {
            //Final logging
            //Disposal of initial objects etc...
        }
