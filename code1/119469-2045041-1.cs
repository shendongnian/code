    public class MagicalArgumentsContainer
        {
                object[] _myParams;
                
                public MagicalArgumentsContainer (params object[] myParams)
                {
                _myParams = myParams;
                }
                
                public Thing GimmieAThing()
                {
        return new Thing(_myParams[0], _myParams[1], _myParams[2], _myParams[3]);
            }
        }
