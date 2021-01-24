    foreach (var indicator in ListServoInputs) {
        if (indicator.Checked) {
            indicator.BackColor = Color.LawnGreen;
        } else {
            indicator.BackColor = Color.DarkGray;
        }
    }
