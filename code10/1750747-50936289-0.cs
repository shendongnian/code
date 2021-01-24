    using Newtonsoft.Json.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class generateUI : MonoBehaviour
    {
        public static int size = 0;
        public static List<Dictionary<string, string>> abc = new List<Dictionary<string, string>>();
        public GameObject canvas;
        public GameObject Panel;
        public GameObject image;
        public GameObject imagetext;
        private float scaler = 0.0125f;
        void Start()
        {
            string json = "{\"PC_Station\": [{\"PLC_0\": {\"DB1\": {\"test123\": 0}, \"STOP\": false, \"START\": false, \"Start_1\": false, \"Stop_1\": false, \"Led1\": true, \"Led2\": false, \"Led3\": true, \"Counter\": 4002, \"Sliderval\": 0}}]}";
            //string json = "{\"PC_Station\": [{\"PLC_0\": {\"DB1\": {\"test123\": 0}, \"STOP\": false, \"START\": false, \"Start_1\": false, \"Stop_1\": false, \"Led1\": true, \"Led2\": false, \"Led3\": true, \"Counter\": 4002, \"Sliderval\": 0}},{\"PLC_1\": {\"DB1\": {\"test123\": 0}, \"STOP\": false, \"START\": false, \"Start_1\": false, \"Stop_1\": false, \"Led1\": true, \"Led2\": false, \"Led3\": true, \"Counter\": 4002, \"Sliderval\": 0}}]}";
            Panel.transform.SetParent(canvas.transform, false);
            var root = JToken.Parse(json);
            IterateJtoken(root);
            List<string> varz = new List<string>();
            foreach(var item in abc)
            {
                foreach(var it in item)
                {
                    varz.Add(it.Key);
                }
            }
    
    
    
    
            GameObject[] tiles = new GameObject[size];
            GameObject[] texts = new GameObject[size];
            int tilenum = 0;
            for (int i = 0; i < size; i++)
            {
                tilenum++;
                tiles[i] = Instantiate(image, transform.position, transform.rotation);
                tiles[i].name = "tile"+tilenum;
                tiles[i].transform.SetParent(Panel.transform, false);
                texts[i] = Instantiate(imagetext, transform.position, transform.rotation);
                texts[i].transform.SetParent(tiles[i].transform, false);
                texts[i].GetComponent<Text>().text = varz[i];
                texts[i].transform.position += new Vector3(55*scaler, -4*scaler, 0);
            }
        }
    
        public static void test()
        {
            int i = 0;
            foreach(var item in abc)
            {
                foreach(var it in item)
                {
                    i++;
                }
            }
            Debug.Log(i);
        }
    
        public static void IterateJtoken(JToken jtoken)
        {
            foreach (var value in jtoken)
            {
                foreach (JArray test in value)
                {
                    for (int i = 0; i < test.Count; i++)
                    {
                        foreach (var item in test[i])
                        {
                            var itemproperties = item.Parent;
                            foreach (JToken token in itemproperties)
                            {
                                if (token is JProperty)
                                {
                                    var prop = token as JProperty;
                                    //Console.WriteLine(prop.Name);           //PLC name
                                    var plc = (JObject)prop.Value;
                                    Dictionary<string, string> variables = new Dictionary<string, string>();
                                    foreach (KeyValuePair<string, JToken> val in plc)
                                    {
                                        
                                        if (val.Value is JObject)
                                        {
                                            JObject nestedobj = (JObject)val.Value;
                                            foreach (JProperty nestedvariables in nestedobj.Properties())
                                            {
                                                size++;
                                                var nestedVariableName = nestedvariables.Name;
                                                var nestedVariableValue = nestedvariables.Value;
                                                variables.Add(nestedVariableName, nestedVariableValue.ToString());
                                                //Console.WriteLine(nestedVariableName+" "+nestedVariableValue);
                                            }
    
                                        }
                                        else
                                        {
                                            size++;
                                            var variableName = val.Key;
                                            var variableValue = val.Value;
                                            variables.Add(variableName, variableValue.ToString());
                                            //Console.WriteLine(variableName+" "+variableValue);
                                        }
                                        
                                    }
                                    abc.Add(new Dictionary<string, string>(variables));
                                }
                            }
                        }
                    }
                }
    
    
            }
    
        }
    }
