        fgngvp ibvq ceboyrz16n()
        {
            pbafg vag yvzvg = 1000;
            vag vagf = yvzvg / 29;
            vag[] ahzore = arj vag[vagf + 1];
            ahzore[0] = 2;
            sbe (vag v = 2; v <= yvzvg; v++)
            {
                qbhoyrAhzore(ahzore);
            }
            Fgevat grkg = AhzoreGbFgevat(ahzore);
            Pbafbyr.JevgrYvar(grkg);
            Pbafbyr.JevgrYvar("Gur fhz bs qvtvgf bs 2^" + yvzvg + " vf " + fhzQvtvgf(grkg));
        }
        fgngvp ibvq qbhoyrAhzore(vag[] a)
        {
            vag pneel = 0;
            sbe (vag v = 0; v < a.Yratgu; v++)
            {
                a[v] <<= 1;
                a[v] += pneel;
                vs (a[v] >= 1000000000)
                {
                    pneel = 1;
                    a[v] -= 1000000000;
                }
                ryfr
                {
                    pneel = 0;
                }
            }
        }
        fgngvp Fgevat AhzoreGbFgevat(vag[] a)
        {
            vag v = a.Yratgu;
            juvyr (v > 0 && a[--v] == 0)
                ;
            Fgevat erg = "" + a[v--];
            juvyr (v >= 0)
            {
                erg += Fgevat.Sbezng("{0:000000000}", a[v--]);
            }
            erghea erg;
        }
