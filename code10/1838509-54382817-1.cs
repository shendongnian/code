protected void timerElapsed(object sender, ElapsedEventArgs e) {
        try
        {
            timerToDisableCamera.Stop();
            timerToDisableCamera.Elapsed -= new ElapsedEventHandler(timerElapsed);
            RunOnUiThread(() => {
                Vibrator vibrator = (Vibrator)GetSystemService(Context.VibratorService);
                vibrator.Vibrate(1000);
                camara.Stop();
                btnEncenderCamara.Enabled = true;
                Toast.MakeText(this, "La cámara se ha detenido para ahorrar en cosumo de batería. Presione 'ENCENDER CÁMARA' para encender la cámara nuevamente", ToastLength.Short).Show();
            });
        }
        catch (Exception ex)
        {
            throw;
        }
    }
Alternatively, you could refactor your code to initialize the timer just once, which will keep your logic lean, something like this:
// I'm assuming this method is an entry point for initialization in your Android activity.
void OnLoad()
{
    // I'm assuming timerToDisableCamera already have an instance of Timer, otherwise you will get a NullReferenceException.
    timerToDisableCamera.Interval = 6000;
    timerToDisableCamera.Elapsed += new ElapsedEventHandler(timerElapsed);
    // And also assuming that btnEncenderCamara is already an instance of Button.
    btnEncenderCamara.Click += (sender, e) => {
        camara.Start(lectorQR.Holder);
        btnEncenderCamara.Enabled = false;
        timerToDisableCamera.Start();
    };
}
protected void timerElapsed(object sender, ElapsedEventArgs e)
{
    try
    {
        timerToDisableCamera.Stop();
        RunOnUiThread(() => {
            Vibrator vibrator = (Vibrator)GetSystemService(Context.VibratorService);
            vibrator.Vibrate(1000);
            camara.Stop();
            btnEncenderCamara.Enabled = true;
            Toast.MakeText(this, "La cámara se ha detenido para ahorrar en cosumo de batería. Presione 'ENCENDER CÁMARA' para encender la cámara nuevamente", ToastLength.Short).Show();
        });
    }
    catch (Exception ex)
    {
        throw;
    }
}
