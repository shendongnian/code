        public static PredictionModel<TaxiTrip, TaxiTripFarePrediction> Train()
        {
            var pipeline = new LearningPipeline();
            pipeline.Add(new TextLoader(_datapath).CreateFrom<TaxiTrip>(useHeader: true, separator: ','));
            Type obj = AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes()).
                Where(t => String.Equals(t.Name, "LearningPipelineDebugProxy", StringComparison.Ordinal)).First();
            var instObject = Activator.CreateInstance(obj, new []{pipeline});
            pipeline.Add(new ColumnCopier(("FareAmount", "Label")));
            pipeline.Add(new CategoricalOneHotVectorizer("VendorId", "RateCode", "PaymentType"));
            pipeline.Add(new ColumnConcatenator("Features", "VendorId", "RateCode", "PassengerCount", "TripDistance", "PaymentType"));
            var rws = GetPropValue(instObject, "Rows");
            var clms = GetPropValue(instObject, "Columns");
            pipeline.Add(new FastTreeRegressor());
            PredictionModel<TaxiTrip, TaxiTripFarePrediction> model = pipeline.Train<TaxiTrip, TaxiTripFarePrediction>();
            return model;
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
