                public string semantic;
                speechRecognizer.SpeechRecognized += (s, e) =>
                {
                       semantic = (string)e.Result.Semantics["result"].Value;
                };
