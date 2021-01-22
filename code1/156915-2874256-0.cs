	#include "vpx_codec.h"
	#define VPX_CODEC_DISABLE_COMPAT 1
	#include "vpx_encoder.h"
	#include "vp8cx.h"
	#define vp8iface (&vpx_codec_vp8_cx_algo)
	using namespace System;
	namespace WebM
	{
		namespace VP8 
		{
			namespace Native
			{
				public ref class VP8Codec
				{
				private:
					vpx_codec_ctx_t* ctx;
					VP8Codec(vpx_codec_ctx_t* ctx)
					{
						this->ctx = ctx;
					}
				public:
					~VP8Codec()
					{
						vpx_codec_destroy(ctx);
						delete ctx;
					}
					property String^ LastError
					{
						String^ get()
						{
							return gcnew String(vpx_codec_error(ctx));
						}
					}
					property String^ LastErrorDetail
					{
						String^ get()
						{
							return gcnew String(vpx_codec_error_detail(ctx));
						}
					}
				
					int Encode()
					{
						// TODO: do actual encoding
						return
							vpx_codec_encode(ctx, NULL, 0, 1, 0, VPX_DL_REALTIME); 
					}
					static VP8Codec^ CreateEncoder() // TODO: add 'config' argument
					{
						vpx_codec_ctx_t* ctx;
						vpx_codec_enc_cfg_t cfg;
					
						if(vpx_codec_enc_config_default(vp8iface, &cfg, 0))
						{
							return nullptr; // TODO: throw exception
						}
						ctx = new vpx_codec_ctx_t;
						if (vpx_codec_enc_init(ctx, vp8iface, &cfg, 0))
						{
							delete ctx;
							return nullptr; // TODO: throw exception
						}
					
						return gcnew VP8Codec(ctx);
					}
					static property int Version
					{
						int get()
						{
							return vpx_codec_version();
						}
					}
					static property String^ VersionString
					{
						String^ get()
						{
							return gcnew String(vpx_codec_version_str());
						}
					}
					static property String^ BuildConfig
					{
						String^ get()
						{
							return gcnew String(vpx_codec_build_config());
						}
					}
					static String^ GetErrorDescription(int errorCode)
					{
						return gcnew String(
							vpx_codec_err_to_string((vpx_codec_err_t)errorCode));
					}
					static property String^ IfaceName
					{
						String^ get()
						{
							return gcnew String(vpx_codec_iface_name(vp8iface));
						}
					}
				}
			}
		}
	}
