    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class DialogueSuper : MonoBehaviour
	{
		public IChoiceHandler ch = null;
		public DialogueSuper(IChoiceHandler ch)
		{
			this.ch = ch;
		}
		// Use this for initialization
		void Start()
		{
		}
		// Update is called once per frame
		void Update()
		{
		}
		public void end()
		{
			ch.Next()
		}
	}
