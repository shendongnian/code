    ProductionDependencyFactory depFactory = new ProductionDependencyFactory();
        try
        {
            DateTime beginServiceDateTime = DateTime.Parse(textBeginServiceDateTime.Text);
            DateTime beginStationDateTime = DateTime.Parse(textBeginStationDateTime.Text);
            DateTime endServiceDateTime = DateTime.Parse(textEndServiceDateTime.Text);
            DateTime endStationDateTime = DateTime.Parse(textEndStationDateTime.Text);
            NormalTrainTimeMilageCalculator calculator = depFactory.Create<NormalTrainTimeMilageCalculator>();
            calculator.BeginStation = textBeginStation.Text;
            calculator.BeginServiceDateTime = beginServiceDateTime;
            calculator.BeginStationDateTime = beginStationDateTime;
            calculator.EndStationDateTime = endStationDateTime;
            calculator.EndServiceDateTime = endServiceDateTime;
            calculator.EndStation = textEndStation.Text;
            labelTotalHour.Text = calculator.TotalTime().Hours.ToString();
            labelTotalMinute.Text = calculator.TotalTime().Minutes.ToString();
            labelTotalMilage.Text = calculator.TotalMilage().ToString();
        }
        catch (Exception)
        {
            // Do nothing
        }
