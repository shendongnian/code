    Uri url = new Uri("https://www.86tempobet.com?reloadlive=240671122&no_write_sess=1");
    System.Net.WebClient client = new System.Net.WebClient();
    client.Headers.Add ("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36");
    client.Headers.Add("method","POST");
    client.Headers.Add("cookie","visid_incap_1875943=C4HkVjo8RCCFldh593iChSbq6VsAAAAAQUIPAAAAAABzSYMXxV4TSKKZijRL24QX; incap_ses_277_1875943=ZnjKE7twmRYrT7s2YxvYAybq6VsAAAAAFdaEfL/KiNMUMywbnQeCNA==; GAMBLINGSESS=jfr3uadgl1ogv55c06ee6mvvs3fiv86p; nlbi_1875943=4NdhZ5rR80YChdm11QdqAQAAAAA3PlRp/yXvrsgK9rbvAEPs; _ga=GA1.2.449421393.1542056499; _gid=GA1.2.2110672116.1542056499; docscrollltop=0; LPVID=FkMTc4MDEwMzY3NDllNjU5; LPSID-34568906=eQOy1bjvTWS3lx1mTF5b3w");
    client.Headers.Add("x-requested-with","XMLHttpRequest");
    client.Headers.Add("betslip-hash","578c9b9896d955c14a698bf17937400a");
    client.Headers.Add("content-type","application/x-www-form-urlencoded; charset=UTF-8");
    client.Headers.Add("ajax-json","true");
    
    string jsonOneXBetData = client.DownloadString(url);
