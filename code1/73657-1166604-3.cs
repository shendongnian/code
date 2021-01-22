    public static GUIFactory createOsSpecificFactory() {
            int sys = readFromConfigFile("OS_TYPE");
            if (sys == 0) {
                return new WinFactory();
            } else {
                return new OSXFactory();
            }
        }
