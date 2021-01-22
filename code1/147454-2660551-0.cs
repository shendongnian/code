    public class MyDTO
    {
        public string thread_topic { get; set; }
        public DateTime post_time { get; set; }
        public string user_display_name { get; set; }
        public string user_signature { get; set; }
        public string user_avatar { get; set; }
        public string post_topic { get; set; }
        public string post_body { get; set; }
    }
    var whatevervar = session.CreateSQLQuery(@"select thread_topic, post_time, user_display_name, user_signature, user_avatar, post_topic, post_body
        from THREAD, [USER], POST, THREADPOST
        where THREADPOST.thread_id=" + id + " and THREADPOST.thread_id=THREAD.thread_id and [USER].user_id=POST.user_id and POST.post_id=THREADPOST.post_id
        ORDER BY post_time;")
    .SetResultTransformer(Transformers.AliasToBean(typeof(MyDTO)))
    .List();
