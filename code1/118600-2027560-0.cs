    event ControlNameChangeHandler IProcessBlock.OnControlNameChanged {
        add {
            try {
                Monitor.Enter(ControlNameChanged);
                ControlNameChanged = ControlNameChanged + value;
            }
            finally {
                Monitor.Exit(ControlNameChanged);
            }
        } 
        remove { 
            try {
                Monitor.Enter(ControlNameChanged);
                ControlNameChanged = ControlNameChanged - value;
            }
            finally {
                Monitor.Exit(ControlNameChanged);
            }
        } 
    }
