    public ActionResult UpdateGrid(FormCollection form) {
        // ... Some initialization
        for (int r = 0; r < rowCount; r++ ) {
            for (int c = 0; c < columnCount; c++ ) {
                var cellValue = form[string.format("{1}{0}",(char)(r + 'A'),c  + 1)]; // Excell like format
                // Add your manipulation here;
            }
        }
        // ... Continue your controller implementation
    }
