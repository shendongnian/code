    public class TrainingSet
    {
        private readonly List<string> _attributes = new List<string>();
        private readonly List<List<object>> _examples = new List<List<object>>();
    
        public TrainingSet(params string[] attributes)
        {
          _attributes.AddRange(attributes);
        }
    
        public int AttributesCount
        {
          get { return _attributes.Count; }
        }
    
        public int ExamplesCount
        {
          get { return _examples.Count; }
        }
    
        public TrainingSet AddExample(params object[] example)
        {
          if (example.Length != _attributes.Count)
          {
            throw new InvalidOperationException(
              String.Format("Invalid number of elements in example. Should be {0}, was {1}.", _attributes.Count,
                _examples.Count));
          }
    
    
          _examples.Add(new List<object>(example));
          
          return this;
        }
    
        public static implicit operator Instances(TrainingSet trainingSet)
        {
          var attributes = trainingSet._attributes.Select(x => new Attribute(x)).ToArray();
          var featureVector = new FastVector(trainingSet.AttributesCount);
    
          foreach (var attribute in attributes)
          {
            featureVector.addElement(attribute);
          }
    
          var instances = new Instances("Rel", featureVector, trainingSet.ExamplesCount);
          instances.setClassIndex(trainingSet.AttributesCount - 1);
    
          foreach (var example in trainingSet._examples)
          {
            var instance = new Instance(trainingSet.AttributesCount);
    
            for (var i = 0; i < example.Count; i++)
            {
              instance.setValue(attributes[i], Convert.ToDouble(example[i]));
            }
    
            instances.add(instance);
          }
    
          return instances;
        }
    }
    
    public static class Classifier
    {
    	public static TClassifier Build<TClassifier>(TrainingSet trainingSet)
    	  where TClassifier : weka.classifiers.Classifier, new()
    	{
    	  var classifier = new TClassifier();
    	  classifier.buildClassifier(trainingSet);
    	  return classifier;
    	}
    
    	public static TClassifier Deserialize<TClassifier>(string filename)
    	{
    	  return (TClassifier)SerializationHelper.read(filename);
    	}
    
    	public static void Serialize(this weka.classifiers.Classifier classifier, string filename)
    	{
    	  SerializationHelper.write(filename, classifier);
    	}
    
    	public static double Classify(this weka.classifiers.Classifier classifier, params object[] example)
    	{
    	  // instance lenght + 1, because class variable is not included in example
    	  var instance = new Instance(example.Length + 1);
    
    	  for (int i = 0; i < example.Length; i++)
    	  {
    		instance.setValue(i, Convert.ToDouble(example[i]));
    	  }
    
    	  return classifier.classifyInstance(instance);
    	}
    }
