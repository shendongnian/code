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
