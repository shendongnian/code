    public static void CallPressGas(params Motor[] motors)
    {
        //Here you can iterate through them:
        foreach (var motor in motors)
            motor.PressGas();
    
        //Or if you wanted to use a list (even though you said you didn't)
        motors.ToList().ForEach(m => m.PressGas());
    }
