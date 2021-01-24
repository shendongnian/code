    namespace SerialPort_Listener
    {
        class constants
        {
            const byte PCK_SOP1 = 0xAA;
            const byte PCK_SOP2 = 0xCC;
            const byte PCK_EOP = 0x55;
        }
        public enum CMD_IDs
        {
           ID_READ_VAR = 0,
           ID_WRITE_VAR,
           ID_READ_MEM,
           ID_WRITE_MEM,
           ID_COUNT    
       };
    
       public enum RET_VALs
       {
           PCK_READY = 0,
           PCK_NOT_RDY,
           PCK_INV_ID,
           PCK_CHK_ERR,
           VAL_COUNT
        };
    }
