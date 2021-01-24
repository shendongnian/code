    template<class T> class Series
    {
        // some template class definition
    }
    class UserOfSeries
    {
        Series<double> Values[]; // = ... somewhere
    public:
        Series<double> Avg()
        {
            return Values[1];
        }
        Series<double> Default()
        {
            return Values[0];
        }
    }
