    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Speech.Recognition;
    using System.Speech.Synthesis;
    using System.Windows.Forms;
    
    namespace SpeechTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string MyText = "dolphins"; // Initialze string for storing word (or words) of interest
                string MyPronunciation = GetPronunciationFromText(MyText.Trim()); // Get IPA pronunciations of MyTe
                MessageBox.Show(MyText + " = " + MyPronunciation); // Output MyText and MyPronunciation
            }
            
            public static string recoPhonemes;
    
            public static string GetPronunciationFromText(string MyWord)
            {
                //this is a trick to figure out phonemes used by synthesis engine
    
                //txt to wav
                using (MemoryStream audioStream = new MemoryStream())
                {
                    using (SpeechSynthesizer synth = new SpeechSynthesizer())
                    {
                        synth.SetOutputToWaveStream(audioStream);
                        PromptBuilder pb = new PromptBuilder();
                        //pb.AppendBreak(PromptBreak.ExtraSmall); //'e' wont be recognized if this is large, or non-existent?
                        //synth.Speak(pb);
                        synth.Speak(MyWord);
                        //synth.Speak(pb);
                        synth.SetOutputToNull();
                        audioStream.Position = 0;
    
                        //now wav to txt (for reco phonemes)
                        recoPhonemes = String.Empty;
                        GrammarBuilder gb = new GrammarBuilder(MyWord);
                        Grammar g = new Grammar(gb); //TODO the hard letters to recognize are 'g' and 'e'
                        SpeechRecognitionEngine reco = new SpeechRecognitionEngine();
                        reco.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(reco_SpeechHypothesized);
                        reco.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(reco_SpeechRecognitionRejected);
                        reco.UnloadAllGrammars(); //only use the one word grammar
                        reco.LoadGrammar(g);
                        reco.SetInputToWaveStream(audioStream);
                        RecognitionResult rr = reco.Recognize();
                        reco.SetInputToNull();
                        if (rr != null)
                        {
                            recoPhonemes = StringFromWordArray(rr.Words, WordType.Pronunciation);
                        }
                        //txtRecoPho.Text = recoPhonemes;
                        return recoPhonemes;
                    }
                }
            }
    
            public static string StringFromWordArray(ReadOnlyCollection<RecognizedWordUnit> words, WordType type)
            {
                string text = "";
                foreach (RecognizedWordUnit word in words)
                {
                    string wordText = "";
                    if (type == WordType.Text || type == WordType.Normalized)
                    {
                        wordText = word.Text;
                    }
                    else if (type == WordType.Lexical)
                    {
                        wordText = word.LexicalForm;
                    }
                    else if (type == WordType.Pronunciation)
                    {
                        wordText = word.Pronunciation;
                        //MessageBox.Show(word.LexicalForm);
                    }
                    else
                    {
                        throw new InvalidEnumArgumentException(String.Format("[0}: is not a valid input", type));
                    }
                    //Use display attribute
    
                    if ((word.DisplayAttributes & DisplayAttributes.OneTrailingSpace) != 0)
                    {
                        wordText += " ";
                    }
                    if ((word.DisplayAttributes & DisplayAttributes.TwoTrailingSpaces) != 0)
                    {
                        wordText += "  ";
                    }
                    if ((word.DisplayAttributes & DisplayAttributes.ConsumeLeadingSpaces) != 0)
                    {
                        wordText = wordText.TrimStart();
                    }
                    if ((word.DisplayAttributes & DisplayAttributes.ZeroTrailingSpaces) != 0)
                    {
                        wordText = wordText.TrimEnd();
                    }
    
                    text += wordText;
    
                }
                return text;
            }
    
            public static void reco_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
            {
                recoPhonemes = StringFromWordArray(e.Result.Words, WordType.Pronunciation);
            }
    
            public static void reco_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
            {
                recoPhonemes = StringFromWordArray(e.Result.Words, WordType.Pronunciation);
            }
    
        }
    
        public enum WordType
        {
            Text,
            Normalized = Text,
            Lexical,
            Pronunciation
        }
    }
    
    // Credit for method of retrieving IPA pronunciation from a string goes to Casey Chesnut (http://www.mperfect.net/speechSamples/)
