        // a = double[9];
        // c = Matrix<double>
        for (int ic = 0; ic < c.ColumnCount; ic++)
        {
            for (int ir = 0; ir < c.RowCount; ir++) c[ir, ic] = a[ir] * c[ir, ic];
        }
