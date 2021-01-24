    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Speech.Recognition;
    using System.Speech.Synthesis;
    
    namespace AI_Graph
    {  
    
        public partial class Form1 : Form
        {        
            public SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            public SpeechSynthesizer spekEngine = new SpeechSynthesizer();
    
            public class DemoCode
            {
                public Grammar on_Grammar()
                {
                    Choices oncommands = new Choices();
                    oncommands.Add(new string[] { "Please", "Bye" });
                    GrammarBuilder ongBuilder = new GrammarBuilder();
                    ongBuilder.Append(oncommands);
                    Grammar ongrammar = new Grammar(ongBuilder);
                    ongrammar.Name = "Standby";
    
                    return ongrammar;
                }
    
                public Grammar command_Grammar()
                {
                   Choices commands = new Choices();
                    commands.Add(new string[] { "Turn on the lights", "Bye" });
                    GrammarBuilder gBuilder = new GrammarBuilder();
                    gBuilder.Append(commands);
                    Grammar grammar = new Grammar(gBuilder);
                    grammar.Name = "ON";
    
                    return grammar;
                }
                public Grammar off_Grammar()
                {
                    Choices offcommands = new Choices();
                    offcommands.Add(new string[] { "Hello", "Bye", "Good night", "Good morning" });
                    GrammarBuilder offgBuilder = new GrammarBuilder();
                    offgBuilder.Append(offcommands);
                    Grammar offgrammar = new Grammar(offgBuilder);
                    offgrammar.Name = "OFF";
    
                    return offgrammar;
                }
    
            }
    
            public DemoCode _Grammar = new DemoCode();
    
            public enum ProcessState
            {
                on,
                command,
                off
            }
    
            public ProcessState current_state = ProcessState.off;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            public void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
            here:
                do
                {
                    if (current_state == ProcessState.on)
                    {
                        recEngine.LoadGrammarAsync(_Grammar.on_Grammar());
                        spekEngine.Speak("I'm waiting for your commands");
                        switch (e.Result.Text)
                        {
                            case "Please":
                                current_state = ProcessState.command;
                                richTextBox1.Text += e.Result.Grammar.Name;
                                break;
                            case "Bye":
                                spekEngine.Speak("Bye, bye");
                                current_state = ProcessState.off;
                                richTextBox1.Text += e.Result.Grammar.Name;
                                break;
                        }
                    }
                    if (current_state == ProcessState.command)
                    {
                        recEngine.LoadGrammarAsync(_Grammar.command_Grammar());
                        switch (e.Result.Text)
                        {
                            case "Turn the lights on":
                                spekEngine.Speak("Of course");
                                current_state = ProcessState.on;
                                richTextBox1.Text += e.Result.Grammar.Name;
                                break;
                            case "Bye":
                                spekEngine.Speak("Bye, bye");
                                current_state = ProcessState.off;
                                richTextBox1.Text += e.Result.Grammar.Name;
                                break;
                        }
                    }
                    if (current_state == ProcessState.off)
                    {
                        recEngine.LoadGrammarAsync(_Grammar.off_Grammar());
                        switch (e.Result.Text)
                        {
                            case "Hello":
                                spekEngine.Speak("Hi there");
                                current_state = ProcessState.on;
                                richTextBox1.Text += e.Result.Grammar.Name;
                                break;
                            case "Bye":
                                spekEngine.Speak("Bye, bye");
                                current_state = ProcessState.off;
                                richTextBox1.Text += e.Result.Grammar.Name;
                                break;
                        }
                    }
                } while (e.Result.Text != "Good night");
    
                if (e.Result.Text == "Good morning")
                {
                    goto here;
                }
            }
            public void recEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
            {
                richTextBox1.Text += "  Speech detected at AudioPosition = " + e.AudioPosition;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                recEngine.LoadGrammarAsync(_Grammar.off_Grammar());
                recEngine.SetInputToDefaultAudioDevice();
                spekEngine.SetOutputToDefaultAudioDevice();
                recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            }
    
            private void btnEnable_Click(object sender, EventArgs e)
            {
                recEngine.RecognizeAsync(RecognizeMode.Multiple);
                btnDisable.Enabled = true;
            }
    
            private void btnDisable_Click(object sender, EventArgs e)
            {
                recEngine.RecognizeAsyncStop();
                btnDisable.Enabled = false;
            }
        }
    }
