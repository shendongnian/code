code
var properties = new List<DynamicTypeProperty>()
{
    new DynamicTypeProperty("SepalLength", typeof(float)),
    new DynamicTypeProperty("SepalWidth", typeof(float)),
    new DynamicTypeProperty("PetalLength", typeof(float)),
    new DynamicTypeProperty("PetalWidth", typeof(float)),
};
// create the new type
var dynamicType = DynamicType.CreateDynamicType(properties);
var schema = SchemaDefinition.Create(dynamicType);
You'll then need to create list with the required data.  This is done as follows:
code
var dynamicList = DynamicType.CreateDynamicList(dynamicType);
// get an action that will add to the list
var addAction = DynamicType.GetAddAction(dynamicList);
// call the action, with an object[] containing parameters in exact order added
addAction.Invoke(new object[] {1.1, 2.2, 3.3, 4.4});
// call add action again for each row.
Then you'll need to create an IDataView with the data, this requires using reflection, or the trainers won't infer the correct type.
code
            var mlContext = new MLContext();
            var dataType = mlContext.Data.GetType();
            var loadMethodGeneric = dataType.GetMethods().First(method => method.Name =="LoadFromEnumerable" && method.IsGenericMethod);
            var loadMethod = loadMethodGeneric.MakeGenericMethod(dynamicType);
            var trainData = (IDataView) loadMethod.Invoke(mlContext.Data, new[] {dynamicList, schema});
You then, should be able to run the `trainData` through your pipeline.
Good luck.
