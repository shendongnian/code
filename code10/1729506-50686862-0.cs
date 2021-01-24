    var serializedObject = JsonConvert.SerializeObject(item, Formatting.Indented);
                var deserializedObject = JsonConvert.DeserializeObject<DataContract.Event>(x);
    
                view.FindViewById<TextView>(Resource.Id.textView1).Text = deserializedObject.Name;
                view.FindViewById<TextView>(Resource.Id.textView2).Text = deserializedObject.EventDateTime.ToString();
