          /// <summary>
          /// performs forward or inverse transform of 2D floating-point image
          /// </summary>
          /// <param name="type">Transformation flags</param>
          /// <returns>The result of DCT</returns>
          [ExposableMethod(Exposable = true, Category = "Discrete Transforms")]
          public Image<TColor, Single> DCT(CvEnum.CV_DCT_TYPE type)
          {
             Image<TColor, Single> res = new Image<TColor, float>(Width, Height);
             CvInvoke.cvDCT(Ptr, res.Ptr, type);
             return res;
          }
