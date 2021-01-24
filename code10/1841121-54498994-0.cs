    Matrix<Byte> varType = new Matrix<byte>(data.Cols + 1, 1);
    varType.SetValue((byte) MlEnum.VarType.Numerical); //the data is numerical
    varType[data.Cols, 0] = (byte) MlEnum.VarType.Categorical; //the response is catagorical
    // .....
    using (TrainData td = new TrainData(data, MlEnum.DataLayoutType.RowSample, response, null, null, null, varType))
