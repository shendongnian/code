    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class MyText : MonoBehaviour {
        class TextProperty
        {
            public Font font { set; get; }
            public string textValue { set; get; }
            public FontStyle fontStyle { set; get; }
            public int fontSize { set; get; }
        }
        public Font font;
        public Text t;
	    // Use this for initialization
        void Start()
        {
            var yourT = Instantiate(t, t.transform.position, Quaternion.identity) as Text;
            yourT.transform.SetParent(GameObject.Find("Canvas").transform, false);
            this.SetTextProps(yourT, this.ReturnSomeText());
        }
        void SetTextProps(Text yourText, TextProperty tp)
        {
            yourText.text = tp.textValue;
            yourText.font = tp.font;
            yourText.fontStyle = tp.fontStyle;
            yourText.fontSize = tp.fontSize;
        }
        TextProperty ReturnSomeText()
        {
            TextProperty tp = new TextProperty();
            tp.font = font;
            tp.fontStyle = FontStyle.Bold;
            tp.textValue = "Hello World";
            tp.fontSize = 20;
            return tp;
        }
    }
