    double[,] GetMultidimesionalArray(IEnumerable<double> ienumerable, int nRows, int nColumns) {
        var res = new double[nRows,nColumns];
        using (var iter = ienumerable.GetEnumerator()) {
            for (var r = 0 ; r != nRows ; r++) {
                for (var c = 0 ; c != nColumns; c++) {
                    if (!iter.MoveNext()) {
                        break;
                    }
                    res[r,c] = iter.Current;
                }
            }
        }
       return res;
    }
