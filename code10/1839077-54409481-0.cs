        [Authorize] //assuming you'll want to have users authenticate before they can send the sms
        [RequireHttps]
        public async Task<ActionResult> SendSMS(
                     [Bind(Include = "message_id_pk, message_content, recipient_phone"] Message message)
        {
            db.Messages.Add(message);
            TwilioSmsSender.SendSMS(message);
            return RedirectToAction("Success");
        }
