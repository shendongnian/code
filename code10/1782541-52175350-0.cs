    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            enum MODE
            {
                GERMAN, 
                TICKET,
                WANN, 
                WO,
            }
            enum COROUTINE
            {
                ICE,
                EC,
                IC,
                BARRIEREFREI,
                AUFZUG,
                ROLLTREPPE,
                ZUG,
                BAHN,
                NÄCHSTE
            }
            static void Main(string[] args)
            {
                MODE mode = MODE.TICKET;
                COROUTINE coroutine =   COROUTINE.IC;
                string language = "nächste";
                switch (mode)
                {
                    case MODE.GERMAN :
                        switch (language)
                        {
                            case "Barrierefrei" :
                                Coroutine(COROUTINE.BARRIEREFREI);
                                break;
                            case "Aufzug":
                                Coroutine(COROUTINE.AUFZUG);
                                break;
                            case "Rolltreppe":
                                Coroutine(COROUTINE.ROLLTREPPE);
                                break;
                        }
                        break;
                    case MODE.TICKET:
                        Voice();
                        break;
                    case MODE.WANN:
                        switch (language)
                        {
                            case "Zug":
                                Coroutine(COROUTINE.ZUG);
                                break;
                            case "Bahn":
                                Coroutine(COROUTINE.BAHN);
                                break;
                            case "NÄCHSTE":
                                Coroutine(COROUTINE.NÄCHSTE);
                                break;
                            default :
                                Voice();
                                break;
                        }
                        break;
                    case MODE.WO:
                        switch (coroutine)
                        {
                            case  COROUTINE.EC :
                                Coroutine(COROUTINE.EC);
                                break;
                            case COROUTINE.ICE:
                                Coroutine(COROUTINE.ICE);
                                break;
                            case COROUTINE.IC :
                                Coroutine(COROUTINE.IC);
                                break;
                            default :
                                Train();
                                break;
                        }
                        break;
                    default :
                        Voice();
                        break;
                }
            }
            static void Coroutine(COROUTINE parameter)
            {
            }
            static void Voice()
            {
            }
            static void Train()
            {
            }
        }
    }
