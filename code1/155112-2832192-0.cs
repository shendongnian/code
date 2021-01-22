    class ABC: I1,I2, I3
    {
        void I1.XYZ() { /* .... */ }
        void I2.XYZ() { /* .... */ }
        void I3.XYZ() { /* .... */ }
    }
    ABC abc = new ABC();
    ((I1) abc).XYZ(); // calls the I1 version
    ((I2) abc).XYZ(); // calls the I2 version
