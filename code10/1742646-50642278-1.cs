    #region Interfaces
    public interface IDataPointProcessor
    {
        IDataPointOutput GetOutput();
    }
    public interface IDataPointInput
    {
        IDataPointProcessor GetProcessor();
    }
    public interface IDataPointOutput
    {
        List<string> DebugStrings { get; set; }
    } 
    #endregion
    #region Base Classes
    public abstract class DataPointProcessorBase : IDataPointProcessor
    {
        public abstract IDataPointOutput GetOutput();
    }
    public abstract class DataPointInputBase : IDataPointInput
    {
        public abstract IDataPointProcessor GetProcessor();
    }
    public abstract class DataPointOutputBase : IDataPointOutput
    {
        public List<string> DebugStrings { get; set; }
        public DataPointOutputBase()
        {
            DebugStrings = new List<string>();
        }
    } 
    #endregion
    public class Age_Output : DataPointOutputBase
    {
    }
    public class Age_Input : DataPointInputBase
    {
        public int AgeExact { get; set; }
        public override IDataPointProcessor GetProcessor()
        {
            return new Age_Processor(this);
        }
    }
    public class Age_Processor : DataPointProcessorBase
    {
        public Age_Input Input { get; set; }
        public Age_Processor(Age_Input input)
        {
            Input = input;
        }
        public override IDataPointOutput GetOutput()
        {
            Age_Output output = new Age_Output();
            if (Input.AgeExact > 30)
            {
                output.DebugStrings.Add("Getting old");
            }
            else
            {
                output.DebugStrings.Add("Still young");
            }
            return output;
        }
    }
    public class DecisionEngine
    {
        public void GetDecisions()
        {
            List<IDataPointInput> input = new List<IDataPointInput>();
            input.Add(new Age_Input { AgeExact = 44 });
            foreach (IDataPointInput item in input)
            {
                IDataPointProcessor processor = item.GetProcessor();
                IDataPointOutput output = processor.GetOutput();
            }
        }
    }
