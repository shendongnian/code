    public interface ICalculation
    {
        double [] Calculate(double y, double period, double shift);
        double XVal {get;}
    }
    
    public class SMA : ICalculation
    {
        public override double[] Calculate( double y, double period, double shift )
        {
            // do calculation, setting xval along the way
        }
        // more code
    }
    
    public class EMA : ICalculation
    {
        public override double[] Calculate( double y, double period, double shift )
        {
            // do calculation,  setting xval along the way
        }
        // more code
    }
    
    public class Averages
    {
        public void HandleCalculation( ICalculation calc, double y, double p, double s )
        {
            double[] result = calc.Calculate( y, p, s );
            chart.Series[UITA].Points.DataBindXY( calc.XVal, result );
        }
    }
