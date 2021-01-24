public class Issue
{
        public float label;
        public float[] features; //change this
}
[Using SchemaDefinition for run-time type mapping hints][2]
var inputSchemaDefinition = SchemaDefinition.Create(typeof(Issue), SchemaDefinition.Direction.Both);
inputSchemaDefinition["features"].ColumnType = new VectorType(NumberType.R4, 4);
Then you would create the engine :
var predictionEngine = model.CreatePredictionEngine<InputSchema, Prediction>(model as IHostEnvironment, inputSchemaDefinition, outputSchemaDefinition);
  [1]: https://github.com/dotnet/machinelearning/blob/master/docs/code/SchemaComprehension.md#using-schema-comprehension-to-make-a-data-view-and-to-read-a-data-view
  [2]: http://Using%20SchemaDefinition%20for%20run-time%20type%20mapping%20hints
